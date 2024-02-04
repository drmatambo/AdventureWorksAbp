$(function () {

    $("#CountryFilter :input").on('input', function () {
        dataTable.ajax.reload();
    });

    //After abp v7.2 use dynamicForm 'column-size' instead of the following settings
    //$('#CountryCollapse div').addClass('col-sm-3').parent().addClass('row');

    var getFilter = function () {
        var input = {};
        $("#CountryFilter")
            .serializeArray()
            .forEach(function (data) {
                if (data.value != '') {
                    input[abp.utils.toCamelCase(data.name.replace(/CountryFilter./g, ''))] = data.value;
                }
            })
        return input;
    };

    var l = abp.localization.getResource('AdventureWorksAbp');

    var service = vumbaSoft.adventureWorksAbp.demographics.countries.country;
    var createModal = new abp.ModalManager(abp.appPath + 'Demographics/Countries/Country/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Demographics/Countries/Country/EditModal');

    var dataTable = $('#CountryTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,//disable default searchbox
        autoWidth: false,
        scrollCollapse: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList,getFilter),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('Edit'),
                                visible: abp.auth.isGranted('Demographics.Country.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('Demographics.Country.Delete'),
                                confirmMessage: function (data) {
                                    return l('CountryDeletionConfirmationMessage', data.record.id);
                                },
                                action: function (data) {
                                    service.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l('SuccessfullyDeleted'));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
            {
                title: l('CountryContinentId'),
                data: "continentId"
            },
            {
                title: l('CountrySubcontinentId'),
                data: "subcontinentId"
            },
            {
                title: l('CountryName'),
                data: "name"
            },
            {
                title: l('CountryFormalName'),
                data: "formalName"
            },
            {
                title: l('CountryNativeName'),
                data: "nativeName"
            },
            {
                title: l('CountryIsoTreeCode'),
                data: "isoTreeCode"
            },
            {
                title: l('CountryIsoTwoCode'),
                data: "isoTwoCode"
            },
            {
                title: l('CountryCcnTreeCode'),
                data: "ccnTreeCode"
            },
            {
                title: l('CountryPhoneCode'),
                data: "phoneCode"
            },
            {
                title: l('CountryCapital'),
                data: "capital"
            },
            {
                title: l('CountryCurrency'),
                data: "currency"
            },
            {
                title: l('CountryPopulation'),
                data: "population"
            },
            {
                title: l('CountryEmoji'),
                data: "emoji"
            },
            {
                title: l('CountryEmojiU'),
                data: "emojiU"
            },
            {
                title: l('CountryRemarks'),
                data: "remarks"
            },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewCountryButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
