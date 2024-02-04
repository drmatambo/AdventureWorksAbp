$(function () {

    $("#DistrictCityFilter :input").on('input', function () {
        dataTable.ajax.reload();
    });

    //After abp v7.2 use dynamicForm 'column-size' instead of the following settings
    //$('#DistrictCityCollapse div').addClass('col-sm-3').parent().addClass('row');

    var getFilter = function () {
        var input = {};
        $("#DistrictCityFilter")
            .serializeArray()
            .forEach(function (data) {
                if (data.value != '') {
                    input[abp.utils.toCamelCase(data.name.replace(/DistrictCityFilter./g, ''))] = data.value;
                }
            })
        return input;
    };

    var l = abp.localization.getResource('AdventureWorksAbp');

    var service = vumbaSoft.adventureWorksAbp.demographics.districtCities.districtCity;
    var createModal = new abp.ModalManager(abp.appPath + 'Demographics/DistrictCities/DistrictCity/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Demographics/DistrictCities/DistrictCity/EditModal');

    var dataTable = $('#DistrictCityTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                visible: abp.auth.isGranted('Demographics.DistrictCity.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('Demographics.DistrictCity.Delete'),
                                confirmMessage: function (data) {
                                    return l('DistrictCityDeletionConfirmationMessage', data.record.id);
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
                title: l('DistrictCityCountryId'),
                data: "countryId"
            },
            {
                title: l('DistrictCityStateProvinceId'),
                data: "stateProvinceId"
            },
            {
                title: l('DistrictCityName'),
                data: "name"
            },
            {
                title: l('DistrictCityPopulation'),
                data: "population"
            },
            {
                title: l('DistrictCityStateProvinceCode'),
                data: "stateProvinceCode"
            },
            {
                title: l('DistrictCityCountryCode'),
                data: "countryCode"
            },
            {
                title: l('DistrictCityLatitude'),
                data: "latitude"
            },
            {
                title: l('DistrictCityLongitude'),
                data: "longitude"
            },
            {
                title: l('DistrictCityRemarks'),
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

    $('#NewDistrictCityButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
