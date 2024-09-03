abp.modals.CreateRegionDdl = function () {
    //var abp = abp || {};
    function initModal(modalManager, args) {
        var $modal = modalManager.getModal();
        var $form = modalManager.getForm();

        var $continentDdl = $('#ViewModel_ContinentId');
        var $subcontinentDdl = $('#ViewModel_SubContinentId');
        var $countryDdl = $('#ViewModel_CountryId');

        //$modal.find('h3').css('color', 'red');

        var ContinetDeoultOption = { id: '-1', text: 'Select a Continent' };
        var newOption = new Option(ContinetDeoultOption.text, ContinetDeoultOption.id, true, true)
        $continentDdl.append(newOption)//.trigger('change');

        emptySubcontinentDropdown();
        $subcontinentDdl.prop("disabled", true);

        emptyContryDropdown();
        $countryDdl.prop("disabled", true);

        $continentDdl.on('change', function () {

            if ($(this).val() == "-1") {

                emptySubcontinentDropdown();
                $subcontinentDdl.prop("disabled", true);

                emptyContryDropdown();
                $countryDdl.prop("disabled", true);

            } else {
                abp.ajax({
                    url: '/api/app/subcontinent',
                    method: "GET",
                    dataType: "JSON",
                    data: { ContinentId: $(this).val() },
                    success: function (data) {

                        //console.log(data)
                        emptySubcontinentDropdown();
                        $subcontinentDdl.prop("disabled", false);

                        //Iterate in a loop cicle all the items of a data obect
                        $(data.items).each(function (index, item) {

                            //Creation of new option for a dropdown menu
                            var newOption = new Option(item.name, item.id, false, false)
                            $subcontinentDdl.append(newOption)//.trigger('change');

                            //console.log('SubContinentId: ' + item.id + '} -- {SubContinenteName: ' + item.name + '}')
                            //logSelection();
                        });
                    }
                });
            }
        });

        $subcontinentDdl.on('change', function () {
            if ($(this).val() == "-1") {

                //
                emptyContryDropdown();
                $countryDdl.prop("disabled", true);

            } else {
                abp.ajax({
                    url: '/api/app/country',
                    method: "GET",
                    dataType: "JSON",
                    data: { SubcontinentId: $(this).val() },
                    success: function (data) {

                        emptyContryDropdown();
                        $countryDdl.prop("disabled", false);

                        //Iterate in a loop cicle all the items of a data obect
                        $(data.items).each(function (index, item) {

                            //Creation of new option for a dropdown menu
                            var newOption = new Option(item.name, item.id, false, false)
                            $countryDdl.append(newOption)//.trigger('change');

                            //console.log('SubContinentId: ' + item.id + '} -- {SubContinenteName: ' + item.name + '}')
                            //logSelection();
                        });
                    }
                });
            }
        });

        $countryDdl.on('change', function () {
            $countryDdl = $('#ViewModel_CountryId');
            logSelection();
        });

        //Function to empty the subcontinent Combobox
        function emptySubcontinentDropdown() {
            $subcontinentDdl.empty();
            var ddlDeoultOption = { id: '-1', text: 'Select a Subcontinent' };
            var newOption = new Option(ddlDeoultOption.text, ddlDeoultOption.id, true, true)
            $subcontinentDdl.append(newOption)//.trigger('change');
        }

        //Function to empty the country Combobox
        function emptyContryDropdown() {
            $countryDdl.empty();
            var ddlDeoultOption = { id: '-1', text: 'Select a country' };
            var newOption = new Option(ddlDeoultOption.text, ddlDeoultOption.id, true, true)
            $countryDdl.append(newOption)//.trigger('change');
        }

        //logSelection();

        function logSelection() {
            console.log('initialized the modal...  {' + $continentDdl.val() + '} -- {' + $subcontinentDdl.val() + '} -- {' + $countryDdl.val() + '}');
        };
    };

    return {
        initModal: initModal
    };
};