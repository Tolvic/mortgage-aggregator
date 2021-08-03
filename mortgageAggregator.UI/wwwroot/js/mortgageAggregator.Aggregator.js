var mortgageAggregator = window.mortgageAggregator || {};

mortgageAggregator.Aggregator = (function () {

    function init() {
        var form = getForm()
        preventFormSubmit(form);

        setUpEventBindings();
    }

    function getForm() {
        return $("#mortgage-requirements");
    }

    function preventFormSubmit(form) {
        form.on("submit", function (event) {
            event.preventDefault();
        });
    }

    function setUpEventBindings() {
        var submitButton = getSubmitButton();

        submitButton.on("click", function () {
            getAvailableMortgages();
        });
    }

    function getSubmitButton() {
        return $("#submit-button");
    }

    function getAvailableMortgages() {
        var form = getForm();

        if (validateForm(form)) {
            $.ajax({
                url: "MortgageRequirements/Get",
                type: "POST",
                data: form.serialize(),
                timeout: 30000,
                success: function (data) {
                    hideErrorMessage();
                    updateMortgaeTable(data);
                },
                error: function () {
                    showErrorMessage();
                }
            });
        }
    }

    function validateForm(form) {
        form.validate();
        return form.valid();
    }

    function updateMortgaeTable(newMortgageTable) {
        $("#mortgage-table").replaceWith(newMortgageTable);
    }

    function showErrorMessage() {
        getErrorMessage().show();
    }

    function hideErrorMessage() {
        getErrorMessage().hide();
    }

    function getErrorMessage() {
        return $("#error-message");
    }

    return {
        init: init,
    }
})();