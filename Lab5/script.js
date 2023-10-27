//Завдання1
const PIBRegex = /^[А-Яа-яіІїЇ]{6}\s[А-ЯІЇ]{1}[.][А-ЯІЇ]{1}[.]$/
const variantRegex = /^[1-9][0-9]$/
const groupRegex = /^[А-ЯІЇ]{2}[-][0-9][1-9]$/
const facultyRegex = /^[A-ЯІЇ]{4}$/
const dateOfBirthRegex = /^(0[1-9]|[12][0-9]|3[01])[.](0[1-9]|1[1,2])[.](19|20)\d{2}$/

function validateInput() {
    const PIBInput = document.getElementById("PIBInput")
    const variantInput = document.getElementById("variantInput")
    const groupInput = document.getElementById("groupInput")
    const facultyInput = document.getElementById("facultyInput")
    const dateOfBirthInput = document.getElementById("dateOfBirthInput")

    const PIBValue = document.querySelectorAll("p")[0]
    const variantValue = document.querySelectorAll("p")[1]
    const groupValue = document.querySelectorAll("p")[2]
    const facultyValue = document.querySelectorAll("p")[3]
    const dateOfBirthValue = document.querySelectorAll("p")[4]

    let isWrongInput = false

    if(!PIBRegex.test(PIBInput.value)) {
        PIBInput.style.border = "3px solid red"
        isWrongInput = true
    } else {
        PIBInput.style.border = "1px solid black"
    }

    if(!variantRegex.test(variantInput.value)) {
        variantInput.style.border = "3px solid red"
        isWrongInput = true
    } else {
        variantInput.style.border = "1px solid black"
    }

    if(!groupRegex.test(groupInput.value)) {
        groupInput.style.border = "3px solid red"
        isWrongInput = true
    } else {
        groupInput.style.border = "1px solid black"
    }

    if(!facultyRegex.test(facultyInput.value)) {
        facultyInput.style.border = "3px solid red"
        isWrongInput = true
    } else {
        facultyInput.style.border = "1px solid black"
    }

    if(!dateOfBirthRegex.test(dateOfBirthInput.value)) {
        dateOfBirthInput.style.border = "3px solid red"
        isWrongInput = true
    } else {
        dateOfBirthInput.style.border = "1px solid black"
    }

    if(!isWrongInput){
        PIBValue.innerHTML = "ПІБ: " + PIBInput.value
        variantValue.innerHTML = "Варіант: " + variantInput.value
        groupValue.innerHTML = "Група: " + groupInput.value
        facultyValue.innerHTML = "Факультет: " + facultyInput.value
        dateOfBirthValue.innerHTML = "Дата народження: " + dateOfBirthInput.value
    }
}

//Завдання 2
const table = document.getElementById("table")
const colorInput = document.getElementById("colorInput")

for(let i = 0; i <= 5; i++) {
    const tr = document.createElement('tr')
    for(let j = 1; j<=6; j++) {
        const td = document.createElement('td')
        const value = (i*6) + j
        if(value == 99 % 36){
            td.id = 'cell'
        }
        td.innerText = value
        tr.appendChild(td)
    }
    table.appendChild(tr)
}

const cell = document.getElementById('cell')

cell.addEventListener('mouseover', () => {
    const color = '#' + Math.floor(Math.random() * 16777215).toString(16)
    cell.style.backgroundColor = color 
})

cell.addEventListener('click', () => {
    cell.style.backgroundColor = colorInput.value
})

cell.addEventListener('dblclick', () => {
    cell.style.backgroundColor = colorInput.value
    const tableCells = document.getElementsByTagName("td")
    tableCells[2].style.backgroundColor = colorInput.value
    tableCells[14].style.backgroundColor = colorInput.value
})