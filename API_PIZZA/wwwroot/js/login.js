const url = 'api/Login';

function Login() {
    sessionStorage.clear();
    var myHeaders = new Headers();
    const name = document.getElementById('name').value.trim();
    const password = document.getElementById('password').value.trim();
    myHeaders.append("Content-Type", "application/json");
    var raw = JSON.stringify({
        Name: name,
        Password: password
    })
    var requestOptions = {
        method: "POST",
        headers: myHeaders,
        body: raw,
        redirect: "follow",
    };

    fetch(`${url}`, requestOptions)
        .then((response) => response.text())
        .then((result) => {
                token = result;
                sessionStorage.setItem("token", token)
                location.href = "index.html";
            //}
        }).catch((error) => alert("error", error));

}