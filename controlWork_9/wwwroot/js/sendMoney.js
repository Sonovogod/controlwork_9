$(document).ready(() => {
    $('#sendSummButton').on('click',function (event){
        event.preventDefault();
        const sendSumm = $('#sendSumm').val();
        const sendNumber = $('#sendNumber').val();
        const sendUserName = $('#sendUserName').val();
        const data = {
            UserName: sendUserName,
            Summ: sendSumm,
            AccountNumber: sendNumber
        }

        $.ajax({
            type: 'POST',
            url: '/Transactions/SendMoney/',
            data: data,
            success: function (response){
                $('#closeSendButton').click();
                let element = document.getElementById('succesMessage');
                $('#succesMessage').attr('hidden', false);
                setTimeout(function (){
                    element.hidden = true;
                }, 5000);

            },
            error: function (response){
                console.log(response);
                $('#sendErrors').text(response.responseText);
            }
        })
    })
});