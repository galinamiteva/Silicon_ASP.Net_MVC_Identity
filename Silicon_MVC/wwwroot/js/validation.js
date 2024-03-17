const formErrorHandler = (element, validationResult) => {
    let spanElement = document.querySelector(`[data-valmsg-for="${element.name}"]`)

    if (validationResult) {
        element.classList.remove('input-valitation-error')
        spanElement.classList.remove('field-validation-error')
        spanElement.classList.add('field-validation-valid')
        spanElement.innerHTML = ''
    }

    else {
        element.classList.add('input-valitation-error')
        spanElement.classList.add('field-validation-error')
        spanElement.classList.remove('field-validation-valid')
        spanElement.innerHTML = element.dataset.valRequired
    }
}

const compareValidator = (element, compareValue) => {
    if (element.value === compareValue)
        return true

    return false
}

const textValidator = (element, minLength = 2) => {
    if (element.value.length >= minLength) {
        formErrorHandler(element, true)
    } else {
        formErrorHandler(element, false)
    }
}

const emailValidator = (element) => {
    const regEx = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/
    formErrorHandler(element, regEx.test(element.value))
}

const passValidator = (element) => {
    if (element.dataset.valEqualToOther !== undefined) {
        let password = document.getElementsByName(element.dataset.valEqualtoOther.replace('*', 'Form'))[0].value

        if (element.value === password) {
            formErrorHandler(element, true)
        } else {
            formErrorHandler(element, false)
        }
    } else {
        const regEx = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$/
        formErrorHandler(element, regEx.test(element.value))
    }
}

const phoneValidator = (element) => {
    const regEx = /^\d{10}$/
    formErrorHandler(element, regEx.test(element.value))
}



const checkboxValidator = (element) => {
    if (element.checked) {
        formErrorHandler(element, true)
    } else {
        formErrorHandler(element, false)
    }
}

let forms = document.querySelectorAll('form')
let inputs = document.querySelectorAll('input')

inputs.forEach(input => {
    if (input.dataset.val === 'true') {

        if (input.type === 'checkbox') {
            input.addEventListener('change', (e) => {
                checkboxValidator(e.target)
            })
        }
        else {
            input.addEventListener('keyup', (e) => {
                switch (e.target.type) {
                    case 'text':
                        textValidator(e.target)
                        break
                    case 'email':
                        emailValidator(e.target)
                        break
                    case 'password':
                        passValidator(e.target)
                        break
                    case 'tel':
                        phoneValidator(e.target)
                        break
                }
            })
        }
    }
})

function checkFields() {
    let allFieldsFilled = true;

    inputs.forEach(input => {
        if (!input.value) {
            allFieldsFilled = false;
        }
    });

    const submitButton = document.querySelector('button[type="submit"]');
    if (allFieldsFilled) {
        submitButton.disabled = false;
    } else {
        submitButton.disabled = true;
    }
}

inputs.forEach(input => {
    input.addEventListener('keyup', checkFields);
});

checkFields();
