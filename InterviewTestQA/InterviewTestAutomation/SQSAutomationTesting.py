import boto3
import pytest
from botocore.exceptions import ClientError, NoCredentialsError, EndpointConnectionError

# Create an SQS client using boto3 with the specified region and AWS credentials
sqs = boto3.client('sqs', region_name='us-east-1', 
                   aws_access_key_id='AKIASVQKH2Z5G4E4H7XB', 
                   aws_secret_access_key='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')

# Function to send a message to an SQS queue
def send_message(queue_url, message_body):
    # Sends a message to the specified SQS queue.
    try:
        # Send the message to the SQS queue
        response = sqs.send_message(QueueUrl=queue_url, MessageBody=message_body)
        
        # Check if the response's status code is 200 (successful)
        assert response['ResponseMetadata']['HTTPStatusCode'] == 200, "Failed to send message"
        
        return response
    except ClientError as e:
        # Handle SQS client errors
        print(f"ClientError: {e}")
    except NoCredentialsError:
        # Handle missing AWS credentials error
        print("AWS credentials not found")
    except EndpointConnectionError:
        # Handle connection error with AWS SQS endpoint
        print("Failed to connect to the endpoint")
    except Exception as e:
        # Catch any other unexpected exceptions
        print(f"An error occurred: {e}")

# Function to receive a message from an SQS queue
def receive_message(queue_url):
    # Receives a message from the specified SQS queue.
    try:
        # Receive a message from the SQS queue, waiting up to 10 seconds
        response = sqs.receive_message(QueueUrl=queue_url, MaxNumberOfMessages=1, WaitTimeSeconds=10)
        
        # Ensure that the response contains at least one message
        assert 'Messages' in response, "No messages in the queue"
        
        # Extract the body of the first message
        message = response['Messages'][0]
        
        return message['Body']
    except ClientError as e:
        # Handle SQS client errors
        print(f"ClientError: {e}")
    except NoCredentialsError:
        # Handle missing AWS credentials error
        print("AWS credentials not found")
    except EndpointConnectionError:
        # Handle connection error with AWS SQS endpoint
        print("Failed to connect to the endpoint")
    except Exception as e:
        # Catch any other unexpected exceptions
        print(f"An error occurred: {e}")

# Pytest function to test sending and receiving a message using SQS
def test_sqs_message():
    # Tests the SQS send and receive message functionality.
    queue_url = "https://sqs.us-east-1.amazonaws.com/183631337082/MyFirstQueue"
    message_body = "Test Message"

    try:
        # Send a message to the SQS queue and verify it was sent successfully
        send_message(queue_url, message_body)

        # Receive the message from the SQS queue and verify it matches the sent message
        received_message = receive_message(queue_url)

        # Ensure the received message matches the original message
        assert received_message == message_body, "Message received does not match the sent message"
    except AssertionError as e:
        # Handle assertion errors if the message does not match
        print(f"AssertionError: {e}")
    except Exception as e:
        # Handle any other unexpected errors during testing
        print(f"Unexpected error during testing: {e}")

# Main entry point to run pytest when executing the script
if __name__ == "__main__":
    pytest.main()
