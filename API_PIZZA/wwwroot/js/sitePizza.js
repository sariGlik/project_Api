let basicUrl='https://localhost:7076/api/Pizza/';
const id_=document.getElementById("id");
const name_=document.getElementById("name");
const isGluten_=document.getElementById("isgluten");
//GET ALL
function getAllPizzas()
{
    fetch(`${basicUrl}`)
    .then((res)=>res.json())
    .then((data)=>fillPizzaList(data))
    .catch(err=>{console.log(console.log(err))})
}
//fill list 🖕
function fillPizzaList(pizzaList) {
    var tbody=document.getElementById('pizzatbody');
    pizzaList.forEach(pizza => {
        var tr=document.createElement("tr");
        var td1=document.createElement("td");
        var td2=document.createElement("td");
        var td3=document.createElement("td");
        td1.innerHTML=pizza.id;
        td2.innerHTML=pizza.name;
        td3.innerHTML=pizza.isGluten;
        tr.appendChild(td1);
        tr.appendChild(td2);
        tr.appendChild(td3);
        tbody.append(tr);
    });
}
//ע"י ID
function getPizzaById()
{
 id_.style.display="block";
 document.getElementById("up_date1").style.display="block";
}
function getIdPizza(){
 const id_value=id_.value.trim();
    fetch(`${basicUrl}${id_value}`)
    .then((res) => res.json()) 
    .then((data) => printPizza(data)) 
    .catch(err=>{console.log(err)})
}
//פו שמדפיסה את הנתונים בטבלה
function printPizza(pizza){
    var tbody=document.getElementById('pizzatbody');
        var tr=document.createElement("tr");
        var td1=document.createElement("td");
        var td2=document.createElement("td");
        var td3=document.createElement("td");
        td1.innerHTML=pizza.id;
        td2.append(`${pizza.name}`);
        td3.innerHTML=pizza.isGluten;
        tr.appendChild(td1);
        tr.appendChild(td2);
        tr.appendChild(td3);
        tbody.append(tr);
}
//PUT
function PutPizzaInTheList()
{
    id_.style.display="block";
    name_.style.display="block";
    document.getElementById("up_date2").style.display="block";
}
function PutPizza(){
    const id_val=id_.value.trim();
    const name_val=name_.value.trim();
    fetch(`${basicUrl}${id_val}/${name_val}`,{
        method: 'PUT',
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
         body: JSON.stringify(`{${id_val}/${name_val}}`)
      })
     .then((res) => res.json()) 
     .then((data) =>printPizza(data)) 
     .catch(err=>{console.log(err)})
}
//POST
function PostPizzaToTheList()
{
    isGluten_.style.display="block";
    name_.style.display="block";
    document.getElementById("up_date3").style.display="block";
}
function PostPizza(){
    const namev=name_.value.trim();
    const glutenv=isGluten_.value.trim();
    const Pizza={
        Name:namev,
        isGluten:glutenv,
    }
  let json=`{\"name\": \" ${namev}\", \"gluten\": \ ${glutenv}\}`;
    fetch(`${basicUrl}`,
    {
        method: 'POST',
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        body:json,
        redirect: "follow",
      })
    .then((res) => res.json()) 
    .then((result)=>{
        if(result.includes("400")){
            alert("faild to add!!")
        }
        else{
            alert("The pizza has been successfully added");
        }
    })
    .catch(err=>{console.log(err)})
}
//DELETE
function deleteFromTheList()
{
    id_.style.display="block";
    document.getElementById("up_date4").style.display="block";
}
function deletee()
{  
   const idv=id_.value.trim();
    fetch(`${basicUrl}${idv}`, {
       method:'DELETE'
      })
    .then((result)=>{
    if(result.includes("405"))
    {
        alert("faild to delete!!")
    }
    else
    {
      alert("delete");
    }
    })
    .catch(err => console.log(err));
}
