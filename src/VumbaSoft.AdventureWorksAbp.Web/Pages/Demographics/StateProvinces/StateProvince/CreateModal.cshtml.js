abp.modals.CreateStateProvinceDdl = function () {
    //var abp = abp || {};
    function initModal(modalManager, args) {
        var $modal = modalManager.getModal();
        var $form = modalManager.getForm();

        var $continentDdl = $('#ViewModel_ContinentId');
        var $subcontinentDdl = $('#ViewModel_SubContinentId');
        var $countryDdl = $('#ViewModel_CountryId');
        var $regionDdl = $('#ViewModel_RegionId');

        //$modal.find('h3').css('color', 'red');

        var ContinetDeoultOption = { id: '-1', text: 'Select a Continent' };
        var newOption = new Option(ContinetDeoultOption.text, ContinetDeoultOption.id, true, true)
        $continentDdl.append(newOption)//.trigger('change');

        emptySubcontinentDropdown();
        $subcontinentDdl.prop("disabled", true);

        emptyContryDropdown();
        $countryDdl.prop("disabled", true);

        emptyRegionDropdown();
        $regionDdl.prop("disabled", true);


        $continentDdl.on('change', function () {

            if ($(this).val() == "-1") {

                emptySubcontinentDropdown();
                $subcontinentDdl.prop("disabled", true);

                emptyContryDropdown();
                $countryDdl.prop("disabled", true);

                emptyRegionDropdown()
                $regionDdl.prop("disabled", true);

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

                emptyRegionDropdown()
                $regionDdl.prop("disabled", true);

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

                            logSelection();
                        });
                    }
                });
            }
        });

        $countryDdl.on('change', function () {

            if ($(this).val() == "-1") {

                //
                emptyRegionDropdown();
                $regionDdl.prop("disabled", true);

            } else {
                abp.ajax({
                    url: '/api/app/region',
                    method: "GET",
                    dataType: "JSON",
                    data: { CountryId: $(this).val() },
                    success: function (data) {

                        emptyRegionDropdown();
                        $regionDdl.prop("disabled", false);

                        //Iterate in a loop cicle all the items of a data obect
                        $(data.items).each(function (index, item) {

                            //Creation of new option for a dropdown menu
                            var newOption = new Option(item.name, item.id, false, false)
                            $regionDdl.append(newOption)//.trigger('change');

                            //logSelection();
                        });
                    }
                });
            }
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

        //Function to empty the country Combobox
        function emptyRegionDropdown() {
            $regionDdl.empty();
            var ddlDeoultOption = { id: '-1', text: 'Select a Region' };
            var newOption = new Option(ddlDeoultOption.text, ddlDeoultOption.id, true, true)
            $regionDdl.append(newOption)//.trigger('change');
        }

        //logSelection();

        function logSelection() {
            console.log('initialized the modal...  {' + $continentDdl.val() + '} -- {' + $subcontinentDdl.val() + '} -- {' + $countryDdl.val() + '} -- {' + $regionDdl.val() + '}');
        };
    };

    return {
        initModal: initModal
    };
};