function getJsonInfo() {
    const statusTitle = document.getElementById("status")
    const userRow = document.getElementById("userRow")
    fetch("https://randomuser.me/api").then((response) => {
        return response.json();
    }).then( (obj) => {
        console.log(obj);
        statusTitle.innerText = "Successful"
        const userElement = document.createElement("div")
        userElement.classList.add("userClass")
        const userImage = document.createElement("img")
        const userCity = document.createElement("p")
        const userName = document.createElement("p")
        const userCell = document.createElement("p")
        const userPhone = document.createElement("p")
        userImage.src = obj.results[0].picture["large"]
        userCity.innerText = "City: " + obj.results[0].location["city"]
        userName.innerText = "Name: " + obj.results[0].name["first"] + " " + obj.results[0].name["last"]
        userCell.innerText = "Cell: " + obj.results[0].cell
        userPhone.innerText = "Phone number: " + obj.results[0].phone
        userElement.appendChild(userImage)
        userElement.appendChild(userCity)
        userElement.appendChild(userName)
        userElement.appendChild(userCell)
        userElement.appendChild(userPhone)
        userRow.appendChild(userElement)
    }).catch( (error) => {
        statusTitle.innerText = "Failed"
        console.error(error);
    })
}