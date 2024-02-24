# Loan Calculator Application

This is a simple ASP.NET Core application developed to calculate the cost of housing loans based on user-specified parameters. The application provides a straightforward user interface for inputting the desired loan amount and payback time in number of years, and it generates a monthly payback plan based on the series loan principle with a fixed interest rate.

## Features

- **User Interface**: The application offers a user-friendly interface provided by Swagger UI, where users can easily input the desired loan amount and payback time in number of years.
- **Interest Calculation**: It calculates the monthly payback plan considering a fixed interest rate of 3.5% per year, following the series loan principle.
- **Loan Types**: The application is designed to accommodate different loan types with potentially different interest rates, allowing for flexibility in loan calculations. Currently, only the housing loan type is implemented.
- **Scalability**: The architecture of the application is built to be easily extendable for calculating payment plans for other types of loans, such as car loans or personal loans, with different interest rates or payback schemes.
- **Code Quality and Design**: Emphasis is placed on clean code principles, including KISS (Keep It Simple, Stupid) and DRY (Don't Repeat Yourself). The codebase is designed to be easy to understand, maintain, and extend. Methods are implemented with the Single Responsibility Principle in mind to ensure they have a single reason to change and are considered to avoid unnecessary or over-engineering.

## Sample UI
The images below show sample user interface provided by Swagger UI for inputting loan parameters and viewing payment plans. It provides a sample user input of 2 million loan amount with loan payment duration of 30 years and the resulting payment plan response from the API will have 360 records same as the number of months and will provide the monthlyPayment of 8980.89 and remainingAmount in each month.

Swagger UI Sample user input:
![Swagger UI Sample user input](swagger-ui-sample-user-input.png)

Swagger UI Sample resulting payment plan:
![Swagger UI Sample resulting payment plan](swagger-ui-sample-resulting-payment-plan.png)

## Architecture

The Loan Calculator application follows the Model-View-Controller (MVC) architectural pattern. This architectural pattern divides the application into three interconnected components:

- **Model**: Represents the data and business logic of the application. In this application, models such as `Loan` and `PaymentPlan` define the structure of loan data and payment plans.
- **View**: Represents the user interface of the application. Swagger UI is used to provide a user-friendly interface for inputting loan parameters and viewing payment plans.
- **Controller**: Acts as an intermediary between the model and the view, handling user requests and updating the model as necessary. Controllers such as `LoanController` manage the flow of data between the user interface and the backend logic.

The use of MVC architecture promotes separation of concerns, making the application easier to maintain, test, and extend. It also allows for greater flexibility in modifying and updating different components of the application independently.

## Methods

The application includes the following methods:

- **CalculateInterestRate(Loan loan)**: Calculates the interest rate for the specified loan.
- **CalculatePaymentPlan(Loan loan)**: Generates a monthly payback plan based on the specified loan parameters.

## Test Coverage

The application has good test suite coverage implemented with xUnit test cases. The implemented test coverage ensures that critical parts of the codebase functionality are thoroughly tested, reducing the likelihood of bugs and regressions.

## Installation and Usage

1. **Clone the Repository**: `git clone https://github.com/Mullu/loan-calculator-back.git`
2. **Navigate to the Project Directory**: `cd LoanCalculator`
3. **Build the Application**: `dotnet build`
4. **Run the Application**: `dotnet run`
5. **Access the Application**: Open your web browser and navigate to `http://localhost:5140/swagger/index.html`

## Configuration

The application's configuration is stored in the `appsettings.json` file. Here's an example of the configuration:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

## License

This project is licensed under the MIT License. See the [LICENSE.md](LICENSE.md) file for details.
