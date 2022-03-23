var adminMail="admin";
var adminPass="admin";


var email=document.getElementById("email");
var password=document.getElementById("pass");
function validate ()
{
    if(email.value==adminMail && password.value==adminPass)
    {
        location.replace("admin.html");
    }
    else if(email.value=="" || password.value=="")
    {
        alert("your email or password is empty");
    }
    else{
        location.replace("listmaker.html");
    }
}