@Signup
Feature: User Signup
    As a new user
    I want to create an account on the website
    So that I can access the application features

  Background:
    Given I am on the signup page

  @SignupSuccess
  Scenario: Successful user registration
    When I enter new user signup details
      | Field | Value        |
      | name  | {TEST_USER}  |
      | email | {TEST_EMAIL} |
    And I click the signup button
    And I fill in the account details
      | Field        | Value               |
      | Title        | Mr                  |
      | Password     | {TEST_PASSWORD}     |
      | Day          |                   1 |
      | Month        | January             |
      | Year         |                2020 |
      | First Name   | {TEST_FIRSTNAME}    |
      | Last Name    | {TEST_LASTNAME}     |
      | Company      | {TEST_COMPANY}      |
      | Address1     | {TEST_ADDRESS}      |
      | Address2     | {TEST_ADDRESS2}     |
      | Country      | Canada              |
      | State        | {TEST_STATE}        |
      | City         | {TEST_CITY}         |
      | Zipcode      | {TEST_ZIPCODE}      |
      | Phone Number | {TEST_PHONE_NUMBER} |
    And I click create account button
    Then I should see the account created message
    And I should be logged in successfully


  @AccessSignupPage
  Scenario: Signup page is accessible
    Then the signup page should be visible

  @SignupWithExistedEmail
  Scenario: Signup with existing email
    When I enter existing user signup details
      | Field | Value              |
      | name  | {EXISTED_USERNAME} |
      | email | {EXISTED_EMAIL}    |
    And I click the signup button
    Then I should see email already exists message
    
