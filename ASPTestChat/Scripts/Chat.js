function Send()
{
    
    if ($('#textMessage').val() != '')
    {
        

        var UserName = $("#CurrentUser").val();

        //$('#Deskboard').html($('#Deskboard').html() + "<br/><br/>" + $('#textMessage').val());

        var href = "/Home?chatUser=" + encodeURIComponent(UserName);
        href = href + "&chatMessage=" + encodeURIComponent($('#textMessage').val());
        
        $("#ActionLink").attr("href", href).click();

        var today = new Date();
        
        
        var zeroMonth = (today.getMonth() + 1) < 10 ? "0" : "";
        var zeroDay = today.getDate() < 10 ? "0" : "";
        var zeroHour = today.getHours() < 10 ? "0" : "";
        var zeroMinute = today.getMinutes() < 10 ? "0" : "";
        var zeroSecond = today.getSeconds() < 10 ? "0" : "";

        $('#Deskboard').append("<br/><br/>" + today.getDate() +
            '.' + zeroMonth + (today.getMonth() + 1) +
            '.' + zeroDay + today.getFullYear() + ' ' +
            zeroHour + today.getHours() +
            ":" + zeroMinute+today.getMinutes() +
            ":" + zeroSecond + today.getSeconds() + "<br/><b>"
            + UserName + "</b>:" + $('#textMessage').val());
        
        $("#textMessage").val('');
        
    }
}