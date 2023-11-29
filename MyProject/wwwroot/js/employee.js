var details = document.querySelectorAll(".detail")
var container = document.getElementById("detailProduct");


details.forEach((detail,index) => {
    detail.onclick = function (){
        var name = detail.getAttribute("data-username");
        console.log(name)
        $.ajax({
            url: `/Employee/DetailEmployee/`,
            type: `GET`,
            data: {
                name : name,
            },
            success: function (data){
                console.log(data);
                var render = "";
                data.forEach(product => {
                    render += `
                    <div class="InfoProduct d-flex align-items-start">
                            <div class="me-4">
                                <img
                                    class="img-thumbnail rounded"
                                    src="${product.avatar}"
                                    alt=""
                                    style="width: 7rem; height: 7rem"/>
                            </div>
                            <div class="Info d-flex flex-column justify-content-around">
                                <h5>${product.productName}</h5>
                                <p>${product.price}</p>
                            </div>
                        </div>
                `
                })

                container.innerHTML = render;
            }
        })
    }
})