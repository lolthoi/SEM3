create view completed_orders as select sales.orders.order_id, sales.customers.first_name+' '+sales.customers.last_name as customer_name, sales.orders.order_date, sales.orders.shipped_date, production.products.product_name from sales.orders
inner join sales.customers on sales.orders.customer_id = sales.customers.customer_id 
inner join sales.order_items on sales.orders.order_id = sales.order_items.order_id 
inner join production.products on sales.order_items.product_id = production.products.product_id where order_status = 4;

select * from completed_orders;

create view daily_sale as select sales.orders.order_date, sum(sales.order_items.quantity* sales.order_items.list_price) as daily_sale  from sales.orders
inner join sales.order_items on sales.orders.order_id = sales.order_items.order_id where order_status = 4 group by sales.orders.order_date;

select * from daily_sale;
