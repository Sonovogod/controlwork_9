$(document).ready(() => {
    var providerId
    $('.payFormCallBtn').on('click', function (){
         providerId = $(this).attr('id');
    })
    
    $('#paySummButton').on('click',function (event){
        event.preventDefault();
        const paySumm = $('#paySumm').val();
        const accountProviderId = $('#accountProviderId').val();
        const data = {
            AccountProviderId: accountProviderId,
            Summ: paySumm,
            ProviderId: providerId
        }

        $.ajax({
            type: 'POST',
            url: '/Transactions/PayProviders/',
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