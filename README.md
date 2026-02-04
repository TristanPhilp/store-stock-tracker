Alright, so for a backend price system, we'd be looking at tracking price, quantity in stock, multiple types of product IDs,  and probably some other stuff.
We may also want to develop an API to be called by registers and managers to retrieve prices and update stock. We may also want to include some extra functionality, like automatic ordering of new stock.

In more detailed form:
+ Backend database to house product information (SQL, most likely)
+ API for registers and managers to retrieve and perform functions on the database.
+ For registers, it needs to retrieve the price of a scanned item, and reduce stock after the checkout is complete.
+ For managers, it should be able to view and edit the entire database safely. Update stock, update price, and probably more.
+ QOL functionality, like automatic ordering of low stock or coupon application.  
