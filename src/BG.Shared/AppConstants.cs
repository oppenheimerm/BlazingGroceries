
namespace BG.Shared
{
    public static class AppConstants
    {

        public static string productBaseUrl = "/img/products/";

        public static string ApiGateway = "API-Gateway";

        /// <summary>
        /// Attempt to access service API directly. No access granted;
        /// </summary>
        public static string ServiceIsUnavailable503 = "Sorry, service is unavailable.";

        // CRUD Messages
        public static string SuccessfullyDeletedEntity = "Successfully delete entity";
        public static string SuccssfulOrder = "Successfully placed order";
        public static string SuccessfullyUpdatedEntity = "Entity updated";

        public static string ErrorOccuredExecutingAddRequest = "Error occured executing add request";
        public static string ErrorOccuredExecutingDeleteRequest = "Error occured executing delete request";
        public static string ErrorRetrievingEntity = "Error retrieving entity(ies)";
        public static string EntityNotFound = "Entity not found";
        public static string ErrorUpdatingEntity = "Error occured updating entity";
        public static string ErrorExecutingOrder = "Error occured, could not place order.";
        public static string OrderNotFound = "Order not found.";

        //  HTTP Request / Products
        public static string NoProductsFound = "No products found.";
        public static string ProductNotFount = "Product not found.";

        //  Api Base Urls
        public static string BASE_API_PRODUCT = "/api/product/";
        public static string BASE_API_USER = "/api/user/";

        //  Resilience pipline
        public static string RESILIENCE_PIPELINE = "BG_RETRY_PIPELINE";

    }
}
