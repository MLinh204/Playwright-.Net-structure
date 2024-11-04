@Login
Feature: User Login
  As a user
  I want to use my existing user
  To login to the website

  Background: 
    Given I am on the login page

  @LoginSuccess
  Scenario: Successful login with valid credentials
    When I enter valid values
      | Field    | Value              |
      | email    | {EXISTED_EMAIL}    |
      | Password | {EXISTED_PASSWORD} |
    And I click the login button
    Then I should be logged in

  @LoginWrongEmail
  Scenario: Login Failed with wrong email
    When I enter wrong email and correct Password
      | Field    | Value                  |
      | email    | WrongEmail@gmail.com   |
      | Password | {EXISTED_PASSWORD}     |
    And I click the login button
    Then The error message should be displayed

