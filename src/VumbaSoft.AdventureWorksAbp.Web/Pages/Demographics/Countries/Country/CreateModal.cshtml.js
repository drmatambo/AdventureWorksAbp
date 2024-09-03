abp.modals.CreateCountryDdl = function () {
    //var abp = abp || {};
    function initModal(modalManager, args) {
        var $modal = modalManager.getModal();
        var $form = modalManager.getForm();
        var $continentDdl = $('#ViewModel_ContinentId');
        var $subcontinentDdl = $('#ViewModel_SubcontinentId');

        //$modal.find('h3').css('color', 'red');

        var ContinetDeoultOption = { id: '-1', text: 'Select a Continent' };
        var newOption = new Option(ContinetDeoultOption.text, ContinetDeoultOption.id, true, true)
        $continentDdl.append(newOption)//.trigger('change');
        emptySubcontinent();
        $subcontinentDdl.prop("disabled", true);


        $continentDdl.on('change', function () {
            if ($(this).val() == "-1") {

                emptySubcontinent();
                $subcontinentDdl.prop("disabled", true);

            } else {
                abp.ajax({
                    url: '/api/app/subcontinent',
                    method: "GET",
                    dataType: "JSON",
                    data: { ContinentId: $(this).val() },
                    success: function (data) {

                        //console.log(data)
                        emptySubcontinent();
                        $subcontinentDdl.prop("disabled", false);

                        ////Alternative working code
                        //$subcontinentDdl.empty();
                        //$subcontinentDdl.append($('<option/>', { value: -1, text: 'Select a Sub Continent' }));

                        //Iterate in a loop cicle all the items of a data obect
                        $(data.items).each(function (index, item) {

                            //Working alternative code
                            //$subcontinentDdl.append($('<option/>', { value: item.id, text: item.name }));

                            //Creation of new option for a dropdown menu
                            var newOption = new Option(item.name, item.id, false, false)
                            $subcontinentDdl.append(newOption)//.trigger('change');

                            //console.log('SubContinentId: ' + item.id + '} -- {SubContinenteName: ' + item.name + '}')
                        });
                    }
                });
            }
        });

        function emptySubcontinent() {
            $subcontinentDdl.empty();
            var subContinetDeoultOption = { id: '-1', text: 'Select a Sub Continent' };
            var newOption = new Option(subContinetDeoultOption.text, subContinetDeoultOption.id, true, true)
            $subcontinentDdl.append(newOption)//.trigger('change');
        }


        $subcontinentDdl.on('change', function () {
            $subcontinentDdl = $('#ViewModel_SubcontinentId');
            logSelection();
        });

        //logSelection();

       
        function logSelection() {
            console.log('initialized the modal...  {' + $continentDdl.val() + '} -- {' + $subcontinentDdl.val() + '}');
        };
    };

    return {
        initModal: initModal
    };
};