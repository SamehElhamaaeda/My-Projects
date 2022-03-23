var email=document.getElementById("email");
var fname=document.getElementById("fname");
var lname=document.getElementById("lname");
var pass=document.getElementById("password");
var conPass=document.getElementById("conpassword");
var date=document.getElementById("birthdate");
var mobileNum=document.getElementById("mobnum");
var certificate=document.getElementById("certificate");
var genderMale=document.getElementById("male");
var genderFemale=document.getElementById("female");
var selectbox=document.getElementById("selectcity");
var checkbox=document.getElementById("checkterms");
function validate(){
    
    if(email.value=="")
    {
        alert("email is empty");
        email.focus();
    }
    else if(email.value.indexOf("@")==0 || email.value.indexOf("@")==-1 || email.value.indexOf(".")==-1 )
    {
        alert("email does not valid please re-enter your email");
        email.focus();
    }
    else if(fname.value=="")
    {
        alert("first name is empty");
        fname.focus();
    }
    else if(lname.value=="")
    {
        alert("last name is empty");
        lname.focus();
    }
    else if(pass.value=="")
    {
        alert("password is empty");
        pass.focus();
    }
    else if(pass.value.length<8)
    {
        alert("your password must have at least 8 letters");
        pass.focus();
    }
    else if(conPass.value=="")
    {
        alert("confirm password is empty");
        conPass.focus();
    }
    else if(pass.value!=conPass.value)
    {
        alert("the confirmation password is not similar to the password");
        conPass.focus();
    }
    else if(date.value=="")
    {
        alert("birthdate is empty");
        date.focus();
    }
    else if(mobileNum.value=="")
    {
        alert("mobile number is empty");
        mobileNum.focus();
    }
    else if (certificate.value=="")
    {
        alert("certificate is empty");
        certificate.focus();
    }
    else if(!genderMale.checked && !genderFemale.checked)
    {
        alert("Choose your gender");
    }
    else if(selectbox.options[0].selected)
    {
        alert("Please choose your city");
    }
    else if(!checkbox.checked)
    {
        alert("Please agree on our terms and policy");
    }
    else{
        alert("your account has been created successfully");
        location.replace("listmaker.html");
    }
}

function reset()
{
email.value="";
fname.value="";
lname.value="";
pass.value="";
conPass.value="";
date.value="";
mobileNum.value="";
certificate.value="";
genderMale.checked=false;
genderFemale.checked=false;
selectbox.selectedIndex="0";
checkbox.checked=false;
}