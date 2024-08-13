abp.modals.CreateCountryDdl = function () {
    //var abp = abp || {};
    function initModal(modalManager, args) {
        var $modal = modalManager.getModal();
        var $form = modalManager.getForm();
        var $continentDdl = $('#ViewModel_ContinentId');
        var $subcontinentDdl = $('#ViewModel_SubcontinentId');

        //$modal.find('h3').css('color', 'red');

        $continentDdl.on('change', function () {
            abp.ajax({
                url: '/api/app/subcontinent',
                method: "GET",
                dataType: "JSON",
                data: { ContinentId: $(this).val() },
                success: function (data) {
                    //console.log(data)
                    $subcontinentDdl.prop("disabled", false);
                    $subcontinentDdl.empty();

                    var subContinetDeoultOption = { id: '-1', text: 'Select a Sub Continent' };
                    var newOption = new Option(subContinetDeoultOption.text, subContinetDeoultOption.id,true, true)
                    $subcontinentDdl.append(newOption)//.trigger('change');

                    //Iterate in a loop cicle all the items of a data obect
                    $(data.items).each(function (index, item) {

                        //Creation of new option for a dropdown menu
                        var newOption = new Option(item.name, item.id, false, false)
                        $subcontinentDdl.append(newOption)//.trigger('change');

                        console.log('SubContinentId: ' + item.id + '} -- {SubContinenteName: ' + item.name + '}')
                    });
                }
            });
        });

        $subcontinentDdl.on('change', function () {
            $subcontinentDdl = $('#ViewModel_SubcontinentId');
            logSelection();
        });

        logSelection();
        
        function logSelection() {
            console.log('initialized the modal...  {' + $continentDdl.val() + '} -- {' + $subcontinentDdl.val() + '}');
        };
    };

    return {
        initModal: initModal
    };
};