# EventBrite Project

This web application utilizes microservces to allow users to purchase tickets for events listed in the catalog. This application includes authentication using a token service for users to log into an account. Redis cache is used to keep track of user's carts as they are browsing through the available catalog. When the user is ready to make an order, the cart items are moved to ordering that allows the user to check out using Stripe payment integration. 
 

