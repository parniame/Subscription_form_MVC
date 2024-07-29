
window.addEventListener("DOMContentLoaded", (event) => {

    const names = document.getElementsByClassName("names");
    
    for (var name of names) {
        name.addEventListener('keyup', (e) => {
            validate(e.target, /^[A-Za-z]{3,30}$/);
        });
    }
    const phone = document.getElementById("phoneNumber");
    phone.addEventListener('keyup', (e) => {
        validate(e.target, /^(09)\d{9}$/);
    });
    const code = document.getElementById("courseCode");
    code.addEventListener('keyup', (e) => {
        validate(e.target, /^[2468]\d{2}$/);
    });
    const date = document.getElementById("birthDate");
    date.addEventListener('change', (e) => {
        validate(e.target,ValidateDate(this.value));
    });
    

    

    const form = document.getElementById("Subscription");
    form.addEventListener('submit', (e) => {
        const filed = document.getElementById("birthDate").value;
        if (!ValidateDate(filed)) {
            alert("You must be atleast 18!");
            e.preventDefault();


        }
        else {
            return true;
        }
        
    })
});
function validate(field, regex) {
    var flag = false;
    
    if ((typeof(regex) )==( typeof(false))) {
        if (regex) {
            flag = true;
        }
    }
    else {
        if (regex.test(field.value)) {
            flag = true;

        }
}
   
    if (flag) {
        field.className = 'form-control valid';
    }
    else {
        field.className = 'form-control invalid';
    }
}
function ValidateDate( birthDate) {
    var year_now = new Date().getFullYear();
    if (birthDate != null) {
        
        var birthDate = new Date(birthDate)
        var age = year_now - birthDate.getFullYear()
        if (age > 17) {
            return true
        }
    }
    return false
}
