$(function () {

    $("#ContinentFilter :input").on('input', function () {
        dataTable.ajax.reload();
    });

    //After abp v7.2 use dynamicForm 'column-size' instead of the following settings
    //$('#ContinentCollapse div').addClass('col-sm-3').parent().addClass('row');

    var getFilter = function () {
        var input = {};
        $("#ContinentFilter")
            .serializeArray()
            .forEach(function (data) {
                if (data.value != '') {
                    input[abp.utils.toCamelCase(data.name.replace(/ContinentFilter./g, ''))] = data.value;
                }
            })
        return input;
    };

    var l = abp.localization.getResource('AdventureWorksAbp');

    var service = vumbaSoft.adventureWorksAbp.demographics.continents.continent;
    var createModal = new abp.ModalManager(abp.appPath + 'Demographics/Continents/Continent/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Demographics/Continents/Continent/EditModal');

    var dataTable = $('#ContinentTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                visible: abp.auth.isGranted('Demographics.Continent.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('Demographics.Continent.Delete'),
                                confirmMessage: function (data) {
                                    return l('ContinentDeletionConfirmationMessage', data.record.id);
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
                title: l('ContinentName'),
                data: "name"
            },
            {
                title: l('ContinentPopulation'),
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

                //,render: function (data) {
                //    var number = dataTable.render
                //        .number(',', '.', 2, '$')
                //        .display(data);
                //    return number;
                //}
            },
            {
                title: l('ContinentRemarks'),
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

    $('#NewContinentButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
