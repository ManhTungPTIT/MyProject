var btAdds = document.querySelectorAll("#add");
var totals = document.getElementById("total");
var container = document.getElementById("List_order");
var confirm =document.getElementById("confirm");
var customer = document.getElementById("name_customer");
console.log(customer.value);

updateCartInfo()
btAdds.forEach((button, index) => {
    button.onclick = function (){
        const productId = button.getAttribute("data-productId");
        addToCart(productId);
    }
})

function addToCart(productId){
    $.ajax({
        type: 'POST',
        url: '/Home/AddToCart?productId=' + productId,
        data: {productId: productId},
        success: function () {
            updateCartInfo();
            
        },
        error: function (xhr, status, error) {
            console.log('Failed to add product to cart.');
            console.log('Lỗi AJAX: ' + error);

        }
    });
}

function updateFooter(quantityElement, priecElement){
    console.log(quantityElement);
    var total = 0;
    quantityElement.forEach((quantity, index) => {
        quantity = parseInt(quantityElement[index].value);
        var price = parseInt(priecElement[index].value);
        
        total += quantity * price;
    })
    
    totals.textContent = total;
}

function updateCartInfo() {
    var table = document.getElementById("bill");
    $.ajax({
        type: 'GET',
        url: '/Home/CartInfo',
        success: function (data) {
            var render = "";
            data.forEach(order => {
                render += `
                    <div class="Table-main_item">
                    <div class="Table-main_item-img">
                        <img
                            src="${order.product.avatar}"
                            alt="Anh"/>
                    </div>

                    <div class="Table-main_item-info">
                        <p class="infor-name">${order.product.productName}</p>                    
                        <div class="d-flex flex-row ">
                                <p style="margin-bottom: 0">Số lượng: </p>
                                <input type="number" id="quantity" class="info_quantity ms-5" value="${order.quantity}" readonly/>
                            </div>
                            <div class="d-flex flex-row ">
                                <p style="margin-bottom: 0">Giá tiền: </p>
                                <input type="number" id="totalPrice" class="info_price ms-5" value="${order.product.price}" readonly/>
                            </div>
                                
                    </div>
                </div>
                `;
            })
            
            container.innerHTML = render;
            var quantities = document.querySelectorAll(".info_quantity");
            var prices = document.querySelectorAll(".info_price");
            updateFooter(quantities, prices);
            
        },
        error: function () {
            console.log('Failed to update cart info.');
        }
    });
}

confirm.onclick = function (){
    if(customer.value === ""){
        alert("Vui lòng nhập tên khách hàng")
    }
    else {
        $.ajax({
        url: `/Home/ClearOrder`,
        type: 'GET',
        data: {
            name : customer.value,
        },
        success: function (){
            alert("Đặt đơn thành công")
            window.location.href = "/Home/Index";
        }
    })
    }
}