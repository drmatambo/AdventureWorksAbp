$(function () {

    $("#SubcontinentFilter :input").on('input', function () {
        dataTable.ajax.reload();
    });

    //After abp v7.2 use dynamicForm 'column-size' instead of the following settings
    //$('#SubcontinentCollapse div').addClass('col-sm-3').parent().addClass('row');

    var getFilter = function () {
        var input = {};
        $("#SubcontinentFilter")
            .serializeArray()
            .forEach(function (data) {
                if (data.value != '') {
                    input[abp.utils.toCamelCase(data.name.replace(/SubcontinentFilter./g, ''))] = data.value;
                }
            })
        return input;
    };

    var l = abp.localization.getResource('AdventureWorksAbp');

    var service = vumbaSoft.adventureWorksAbp.demographics.subcontinents.subcontinent;
    //var createModal2 = new abp.ModalManager(abp.appPath + 'Demographics/Subcontinents/Subcontinent/CreateModal');

    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + 'Demographics/Subcontinents/Subcontinent/CreateModal',
        modalClass: 'CreateSubcontinentDdl'
    });

    var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + 'Demographics/Subcontinents/Subcontinent/EditModal',
        modalClass: 'EditSubcontinentDdl'
    });

    var dataTable = $('#SubcontinentTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false, //disable default searchbox
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
                                visible: abp.auth.isGranted('Demographics.Subcontinent.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('Demographics.Subcontinent.Delete'),
                                confirmMessage: function (data) {
                                    return l('SubcontinentDeletionConfirmationMessage', data.record.id);
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
                title: l('SubcontinentName'),
                data: "name"
            },
            {
                title: l('SubcontinentName'),
                data: "continentName"
            },
            {
                title: l('SubcontinentPopulation'),
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
                title: l('SubcontinentRemarks'),
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

    $('#NewSubcontinentButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
