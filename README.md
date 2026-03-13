For a backend price system, we'll be looking at tracking price, quantity in stock, and multiple types of product IDs.
We also want to develop an API to be called by registers and managers to retrieve prices and update stock. We may also want to include some extra functionality, like automatic ordering of new stock based on current trends.

In more detailed form:
+ Backend database to house product information
	- SKU code, product price, unit price, supplier (optionally, expiration data as well)
+ API for registers and managers to retrieve and perform functions on the database.
	- For POS, it needs to retrieve the price of a scanned item, and reduce stock after the checkout is complete.
	- For employees, more advanced functions. View tracked inventory and price, and apply updates to stock count.
	- For managers, it should be able to view and edit the entire database safely. Update stock, update price, view current stock and price, view sales history, and possibly more.
 	- https://bestbuyapis.github.io/api-documentation/#trending-products potential api for predictive supply
+ Expanded features
	- Automatic ordering of stock when low dependant on trends
	- Store analytics, like determining slow-moving products, products that expire more than sell, and buyer trends
	- Web dashboard for remote and mobile devices

+Known Bugs/Plans
	- No input verification
	- Inconsistent code
	- Make architecture cleaner


	-Look up other inventory managers