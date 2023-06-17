$(document).ready(() => {
    $('#sendMoneyButton').on('click',function (event){
        event.preventDefault();
        const inputSumm = $('#inputSumm').val();
        const inputAccountNumber = $('#inputAccountNumber').val();
        const inputUserName = $('#inputUserName').val();
        const data = {
            UseName: inputUserName,
            Summ: inputSumm,
            AccountNumber: inputAccountNumber
        }

        $.ajax({
            type: 'POST',
            url: '/Transactions/TopUpAccount/',
            data: data,
            success: function (response){
                $('#closeSendMoneyButton').click();
                let element = document.getElementById('succesMessage');
                $('#succesMessage').attr('hidden', false);
                setTimeout(function (){
                    element.hidden = true;
                }, 5000);

            },
            error: function (response){
                console.log(response);
                $('#topUpError').text(response.responseText);
            }
        })
    })
});