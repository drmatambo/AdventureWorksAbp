abp.modals.CreateStateProvinceDdl = function () {
    //var abp = abp || {};
    function initModal(modalManager, args) {
        var $modal = modalManager.getModal();
        var $form = modalManager.getForm();
        var $continentId = $('#ViewModel_ContinentId');
        var $subcontinentId = $('#ViewModel_SubcontinentId');

        //$modal.find('h3').css('color', 'red');


        $continentId.on('change', function () {
            $continentId = $('#ViewModel_ContinentId');
            logSelection();
        });

        $subcontinentId.on('change', function () {
            $subcontinentId = $('#ViewModel_SubcontinentId');
            logSelection();
        });

        logSelection();

        function logSelection() {
            console.log('initialized the modal...  {' + $continentId.val() + '} -- {' + $subcontinentId.val() + '}');
        };

    };

    return {
        initModal: initModal
    };
};