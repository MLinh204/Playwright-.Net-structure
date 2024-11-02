using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaywrightTests.config
{
    public class ConfigElement
    {
        //Login-Signup data
        public const String TEST_USER = "Test";
        public const String TEST_EMAIL = "TestEmail@Gmail.com";
        public const String TEST_PASSWORD = "Test123";
        public const String EXISTED_USERNAME = "TestUser";
        public const String EXISTED_EMAIL = "ExistedUser@gmail.com";
        public const String EXISTED_USER_PASSWORD = "Test123";
        public const String TEST_FIRSTNAME = "Test";
        public const String TEST_LASTNAME = "QA";
        public const String TEST_COMPANY = "Test Company";
        public const String TEST_ADDRESS = "Test Street, Test city";
        public const String TEST_ADDRESS2 = "Test Street 2, Test city 2";
        public const String TEST_STATE = "Test State";
        public const String TEST_CITY = "Test city";
        public const String TEST_ZIPCODE = "1231234";
        public const String TEST_PHONE_NUMBER = "1234567890";


        //Signup variables
        public const String SIGNUP_FIRSTNAME_NAME = "first_name";
        public const String SIGNUP_LASTNAME_NAME = "last_name";
        public const String SIGNUP_COMPANY_NAME = "company";
        public const String SIGNUP_ADDRESS1_NAME = "address1";
        public const String SIGNUP_ADDRESS2_NAME = "address2";
        public const String SIGNUP_STATE_NAME = "state";
        public const String SIGNUP_CITY_NAME = "city";
        public const String SIGNUP_ZIPCODE_NAME = "zipcode";
        public const String SIGNUP_PHONE_NUMBER_NAME = "mobile_number";

        //Message
        public const String ACCOUNT_CREATED_MESSAGE = "ACCOUNT CREATED!";
        public const String LOGGEDIN_TEXT_MESSAGE = " Logged in as " + TEST_USER;
        public const String LOGGEDIN_TEXT_EXISTED_USER_MESSAGE = " Logged in as " + EXISTED_USERNAME;
        public const String EMAIL_EXIST_MESSAGE = "Email Address already exist!";
        public const String WRONG_AUTHENTICATION_MESSAGE = "Your email or password is incorrect!";

    }
}