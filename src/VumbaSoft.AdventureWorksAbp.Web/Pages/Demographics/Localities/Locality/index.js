$(function () {

    $("#LocalityFilter :input").on('input', function () {
        dataTable.ajax.reload();
    });

    //After abp v7.2 use dynamicForm 'column-size' instead of the following settings
    //$('#LocalityCollapse div').addClass('col-sm-3').parent().addClass('row');

    var getFilter = function () {
        var input = {};
        $("#LocalityFilter")
            .serializeArray()
            .forEach(function (data) {
                if (data.value != '') {
                    input[abp.utils.toCamelCase(data.name.replace(/LocalityFilter./g, ''))] = data.value;
                }
            })
        return input;
    };

    var l = abp.localization.getResource('AdventureWorksAbp');

    var service = vumbaSoft.adventureWorksAbp.demographics.localities.locality;
    var createModal = new abp.ModalManager(abp.appPath + 'Demographics/Localities/Locality/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Demographics/Localities/Locality/EditModal');

    var dataTable = $('#LocalityTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,//disable default searchbox
        autoWidth: false,
        scrollCollapse: true,
        order: [[7, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList,getFilter),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('Edit'),
                                visible: abp.auth.isGranted('Demographics.Locality.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('Demographics.Locality.Delete'),
                                confirmMessage: function (data) {
                                    return l('LocalityDeletionConfirmationMessage', data.record.id);
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
                title: l('LocalityContinentName'),
                data: "continentName"
            },
            {
                title: l('LocalitySubcontinentName'),
                data: "subcontinentName"
            },
            {
                title: l('LocalityCountryName'),
                data: "countryName"
            },
            {
                title: l('LocalityRegionName'),
                data: "regionName"
            },
            {
                title: l('LocalityStateProvinceName'),
                data: "stateProvinceName"
            },
            {
                title: l('LocalityDistrictCityName'),
                data: "districtCityName"
            },
            {
                title: l('LocalityName'),
                data: "name"
            },
            {
                title: l('LocalityPopulation'),
                data: "population"
            },
            {
                title: l('LocalityDistrictCityCode'),
                data: "districtCityCode"
            },
            {
                title: l('LocalityLocalityCode'),
                data: "localityCode"
            },
            {
                title: l('LocalityLatitude'),
                data: "latitude"
            },
            {
                title: l('LocalityLongitude'),
                data: "longitude"
            },
            {
                title: l('LocalityRemarks'),
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

    $('#NewLocalityButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
