# PrescriptionHQ
Back-End Capstone

## Overview

This version of PrescriptionHQ provides functionality for three roles. The roles include doctors, members (patients) and a pharmacy. 
These roles allows for the streamlining of prescribing, disbursing and refilling prescriptions. Doctors are able to assign medication 
to each patient with the request routed through the pharmacy. The pharmacy verifies, notifies and disburse the prescription to the 
patient. Once a patient prescription is ready for pickup, they will be notified via email to minimize wait time at the pharmacy. The 
patients have access to all active prescriptions and have the ability to request a refill from their login page. 

## Setup

1. Clone the PrescriptionHQ repository to your machine..
1. Open the  project in Visual Studio 2019 or other Integrated Development Environment (IDE) 
1. Install Azure Data Studio or other SQL database management system.
1. Setup Database (Using Visual Studio 2019)
   1. Select tools
   1. Select nuget package manager
   1. Select package manager console
   1. Input and Execute the following: Add-Migration MigrationName
   1. Input and Execute the following: Update-Database
   1. Verify database executed properly through Azure Data Studio

1. Build the solution for PrescriptionHQ 
1. Upon completion of the application loading:
   1. Register a pharmacy
   1. Register a doctor
   1. Register a member (patient)
1. Login as the doctor to create a prescription using the “Doctor’s Corner” navigation link
1. Login as the pharmacy to assigned the prescription to a patient using the “Requests” navigation link
1. Login as the patient to view active prescriptions and refill medication using the “My Prescriptions” navigation link
1. Enjoy exploring the program!

## ERD

1. Link to ERD used to develop PrescriptionHQ 
   https://dbdiagram.io/d/5d0ad3b0fff7633dfc8e49c8
