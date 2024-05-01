

# .NET 8 Email Service with HTML Body and Attachment

## Overview
This repository hosts a .NET8 application designed to facilitate the sending of emails with HTML body content and optional attachments. Leveraging ASP.NET 8 MVC, it provides a user-friendly interface for users to compose and send emails directly from the web application.

## Features
- Email Composition: Users can compose emails with customizable HTML body content.
- Attachment Support: Option to attach files to the email, enhancing its functionality.
- Validation: Utilizes Data Annotations for input validation to ensure proper data integrity.
- Configuration: Email sender credentials can be configured via the `appsettings.json` file.
- Logging: Integrated logging functionality to capture errors and information during email transmission.
- Dependency Injection: Utilizes dependency injection to manage and inject services like the email service.

## Prerequisites
- .NET8 SDK
- Visual Studio or Visual Studio Code (optional)

## Installation
1. Clone this repository to your local machine.
2. Open the solution in Visual Studio or Visual Studio Code.
3. Build the solution to restore dependencies.

## Usage
1. Configure email sender credentials in the `appsettings.json` file under the `Email` section.
2. Run the application.
3. Navigate to the home page.
4. Fill out the form with the recipient's email address, email subject, and email body.
5. Optionally attach files if needed.
6. Click the "Send Mail" button to dispatch the email.

## Additional Functionality
- File Input: Includes a file input feature for attaching files to emails. Ensure the necessary CSS and JavaScript files are included in your project.
 
- <!-- Add FileInput CSS & JS -->
  <link rel="stylesheet" type="text/css" href="~/FileInput/fileinput.css" media="all" />
  <link rel="stylesheet" type="text/css" href="~/FileInput/all.css">
  <script src="~/FileInput/fileinput.js" type="text/javascript"></script>
  <script src="~/FileInput/theme.js" type="text/javascript"></script>
  <script type="text/javascript">
      $(document).ready(function () {
          $("#Attachment").fileinput({
              'showUpload': false,
              theme: 'fas',
              minFileSize: 1,
              maxFileSize: 1000,
              browseLabel: 'Attachment',
              mainClass: 'fileInputmain',
              dropZoneEnabled: false
          });
      });
  </script>

- Notifications: Utilizes alertify for displaying success and error notifications. Ensure the alertify library files are included in your project.
<!-- alertify -->
<link rel="stylesheet" href="~/lib/alertifyjs/css/alertify.css">
<link rel="stylesheet" href="~/lib/alertifyjs/css/themes/bootstrap.css">
<script src="~/lib/alertifyjs/alertify.js"></script>
<script type="text/javascript">
    alertify.defaults.transition = "slide";
    alertify.defaults.theme.ok = "btn btn-primary";
    alertify.defaults.theme.cancel = "btn btn-danger";
    alertify.defaults.theme.input = "form-control";
</script>
@if (TempData["success"] != null)
{     
    <script type="text/javascript">       
        alertify.alert('@TempData["success"]');
    </script>
}
else if (TempData["error"] != null)
{
    <script type="text/javascript">
        alertify.alert('@TempData["error"]');
    </script>
}


## Project Structure
- `EmailModel.cs`: Defines the model for email composition with properties for recipient email, subject, and body.
- `IEmailService.cs`: Interface outlining methods for the email service.
- `EmailService.cs`: Implements the email service for sending emails with HTML content and attachments.
- `Index.cshtml`: Razor view for the home page featuring the email composition form.
- `EmailTemplate.txt`: HTML template file used for formatting the email body.

## Dependencies
- `System.Net.Mail`: Provides functionality for sending emails.
- `System.Net`: Essential for network operations.
- `Microsoft.Extensions.Configuration`: Enables access to application configuration.
- `Microsoft.Extensions.Logging`: Facilitates logging of errors and information.

## Demo
Visit this link for the Demo :https://emailhtmlattachment20240314030655.azurewebsites.net/

## Contributing
Contributions are encouraged! Please feel free to submit issues or pull requests for enhancements or bug fixes.

## License
This project is licensed under the MIT License. See the LICENSE file for details.

## Contact
For any questions or feedback, please reach out via clementomolayo.net@gmail.com.
