Alright, so for a backend price system, we'd be looking at tracking price, quantity in stock, multiple types of product IDs,  and probably some other stuff.
We may also want to develop an API to be called by registers and managers to retrieve prices and update stock. We may also want to include some extra functionality, like automatic ordering of new stock.

In more detailed form:
+ Backend database to house product information (SQL, most likely)
	- SKU code, product price, unit price, supplier (optionally, expiration data as well)
+ API for registers and managers to retrieve and perform functions on the database.
	- For POS, it needs to retrieve the price of a scanned item, and reduce stock after the checkout is complete.
	- For employees, more advanced functions. View tracked inventory and price, and apply updates to stock count.
	- For managers, it should be able to view and edit the entire database safely. Update stock, update price, and probably more.
+ It seems like we'll need more than that if we want to satisfy the requirements, so here's some other pitches
	- Automatic orders
	- Store analytics, like determining slow-moving products, products that expire more than sell, and demand patterns
	- Web dashboard for remote and mobile devices
	- 
+ For registers, it needs to retrieve the price of a scanned item, and reduce stock after the checkout is complete. If the item is bought as a multiple then a price sum is needed and the stcok needs to be reduced by the correct amount.
+ For managers, it should be able to view and edit the entire database safely. Update stock, update price, and probably more.
+ QOL functionality, like automatic ordering of low stock or coupon application.  
