# Self-Checkout API

This project implements a simple web API for simulating a self-checkout machine in a supermarket. The application is built on the .NET framework.

## Overview

The application simulates the functions of a self-checkout machine, accessible through 4 endpoints.

- POST /api/v1/Stock: Through this endpoint, the machine's inventory can be replenished by providing the appropriate banknotes and coins.
- GET /api/v1/Stock: Through this endpoint, the API returns the current stock of the machine.
- POST /api/v1/Checkout: Through this endpoint, a checkout transaction can be called, requires the price and the bills as parameter, returns the change in bills or coins.
- GET /api/v1/Stock: Through this endpoint, the application shows which bills or coins are banned at the moment, because the machine can't give change for them.

The application uses SQLite database for saving the stock.

## Installation and Running

- Clone the repository to your local machine.
- Open the project in your preferred development environment.
- Start the application in your development environment or using the CLI.
- Access the application through the appropriate endpoints (e.g., http://localhost:5000/api/v1/Stock).
  
## Notes

The application currently only handles HUF currency.
