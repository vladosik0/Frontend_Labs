let clickOnTenthElementState = false
let clickOnEleventhElementState = false
let addedImage = false
function clickOnTenthElement() {
    if(clickOnTenthElementState) {
        let tenthElementColor = document.getElementById("tenthElement").style.backgroundColor
        let tenthElementContentColor = document.getElementById("tenthElementContent").style.color
        document.getElementById("tenthElement").style.backgroundColor = document.querySelector(".eleventhElement").style.backgroundColor
        document.getElementById("tenthElementContent").style.color = document.querySelector(".eleventhElementContent").style.color
        document.querySelector(".eleventhElement").style.backgroundColor = tenthElementColor
        document.querySelector(".eleventhElementContent").style.color = tenthElementContentColor
        return 
    }
    document.getElementById("tenthElement").style.backgroundColor = "red"
    document.getElementById("tenthElementContent").style.color = "blue"
    clickOnTenthElementState = true
}

function clickOnEleventhElement() {
    if(clickOnEleventhElementState) {
        let eleventhElementColor =  document.querySelector(".eleventhElement").style.backgroundColor
        let eleventhElementContentColor = document.querySelector(".eleventhElementContent").style.color
        document.querySelector(".eleventhElement").style.backgroundColor = document.getElementById("tenthElement").style.backgroundColor
        document.querySelector(".eleventhElementContent").style.color = document.getElementById("tenthElementContent").style.color
        document.getElementById("tenthElement").style.backgroundColor = eleventhElementColor
        document.getElementById("tenthElementContent").style.color = eleventhElementContentColor
        return 
    }
    document.querySelector(".eleventhElement").style.backgroundColor = "yellow"
    document.querySelector(".eleventhElementContent").style.color = "aqua"
    clickOnEleventhElementState = true
}

function zoomIn() {
    const img = document.getElementById("insertedImage")
    let width = img.offsetWidth
    let height = img.offsetHeight

    console.log(width)
    console.log(height)

    if(width<=350 && height<=167){
        width += 7.76
        height += 4.04
    }
    img.style.width = `${width}px`
    img.style.height = `${height}px`
    
    console.log(`${width}px`)
    console.log(`${height}px`)
}

function zoomOut() {
    const img = document.getElementById("insertedImage")
    let width = img.offsetWidth
    let height = img.offsetHeight

    console.log(width)
    console.log(height)

    if(width>=117 && height>=41){
        width -= 7.76
        height -= 4.04
    }
    img.style.width = `${width}px`
    img.style.height = `${height}px`
    
    console.log(`${width}px`)
    console.log(`${height}px`)
}

function addPhoto() {
    if(!addedImage) {
    const img = document.createElement("img")
    img.src = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/49/17-07-02-Maidan_Nezalezhnosti_RR74377-PANORAMA.jpg/1920px-17-07-02-Maidan_Nezalezhnosti_RR74377-PANORAMA.jpg"
    img.id = "insertedImage"
    document.body.insertBefore(img, buttonsRow)
    addedImage = true
    }
}

function deletePhoto() {
    if(addedImage) {
        const img = document.getElementById("insertedImage")
        document.body.removeChild(img)
        addedImage = false
    }
}