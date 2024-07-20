$(function () {

    $("#RegionFilter :input").on('input', function () {
        dataTable.ajax.reload();
    });

    //After abp v7.2 use dynamicForm 'column-size' instead of the following settings
    //$('#RegionCollapse div').addClass('col-sm-3').parent().addClass('row');

    var getFilter = function () {
        var input = {};
        $("#RegionFilter")
            .serializeArray()
            .forEach(function (data) {
                if (data.value != '') {
                    input[abp.utils.toCamelCase(data.name.replace(/RegionFilter./g, ''))] = data.value;
                }
            })
        return input;
    };

    var l = abp.localization.getResource('AdventureWorksAbp');

    var service = vumbaSoft.adventureWorksAbp.demographics.regions.region;

    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + 'Demographics/Regions/Region/CreateModal',
        modalClass: 'CreateRegionDdl'
    });

    var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + 'Demographics/Regions/Region/EditModal',
        modalClass: 'EditRegionDdl'
    });

    var dataTable = $('#RegionTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,//disable default searchbox
        autoWidth: false,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList,getFilter),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('Edit'),
                                visible: abp.auth.isGranted('Demographics.Region.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('Demographics.Region.Delete'),
                                confirmMessage: function (data) {
                                    return l('RegionDeletionConfirmationMessage', data.record.id);
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
                title: l('RegionName'),
                data: "name"
            },
            {
                title: l('RegionPopulation'),
                data: "population",
                render: function (data) {
                    var number = DataTable
                        .render
                        .number('.', ',')
                        .display(data, {
                            locale: abp.localization.currentCulture.name
                        }).toLocaleString();
                    return number;
                }
            },
            {
                title: l('RegionCountryName'),
                data: "regionCountryName"
            },
            {
                title: l('RegionCountryCode'),
                data: "countryCode"
            },
            {
                title: l('RegionRegionCode'),
                data: "regionCode"
            },
            {
                title: l('RegionRemarks'),
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

    $('#NewRegionButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
