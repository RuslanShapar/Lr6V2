< form method = "post" asp - action = "OrderDetails" >
    < !--Repeat this block for each product -->
    <label for="ProductName">Product Name:</ label >
    < input type = "text" id = "ProductName" name = "products[0].Name" required >< br >
    < label for= "ProductPrice" > Product Price:</ label >
    < input type = "number" id = "ProductPrice" name = "products[0].Price" required >< br >
    < label for= "ProductQuantity" > Product Quantity:</ label >
    < input type = "number" id = "ProductQuantity" name = "products[0].Quantity" required >< br >
    < !--End of block-- >

    < button type = "submit" > Submit Order </ button >
</ form >