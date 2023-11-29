var confirm = document.getElementById("confirm")
var name = document.getElementById("name_customer");
console.log(name);
console.log(confirm);
confirm.onclick = function (){
    console.log("vao")
    console.log(name.textContent);
    $.ajax({
        url: `/Home/ClearOrder`,
        type: 'GET',
        data: {
            name : name.value,
        },
        success: function (){
            alert("Đặt đơn thành công")
           
        }
    })
}