
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

        public static string ErrorOccuredExecutingAddRequest = "Error occured executing add request";
        public static string ErrorOccuredExecutingDeleteRequest = "Error occured executing delete request";
        public static string ErrorRetrievingEntity = "Error retrieving entity(ies)";
        public static string EntityNotFound = "Entity not found";
        public static string ErrorUpdatingEntity = "Error occured updating entity";

        //  HTTP Request / Products
        public static string NoProductsFound = "No products found.";
        public static string ProductNotFount = "Product not found.";

    }
}
