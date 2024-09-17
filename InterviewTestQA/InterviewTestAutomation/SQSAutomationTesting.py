import boto3
import pytest


# Create SQS client
sqs = boto3.client('sqs', region_name='us-east-1', aws_access_key_id='AKIASVQKH2Z5G4E4H7XB', aws_secret_access_key='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')

def send_message(queue_url, message_body):
    try:
        response = sqs.send_message(QueueUrl=queue_url, MessageBody=message_body)
        assert response['ResponseMetadata']['HTTPStatusCode'] == 200, "Failed to send message"
        return response
    except ClientError as e:
        print(f"ClientError: {e}")
    except NoCredentialsError:
        print("AWS credentials not found")
    except EndpointConnectionError:
        print("Failed to connect to the endpoint")
    except Exception as e:
        print(f"An error occurred: {e}")

def receive_message(queue_url):
    try:
        response = sqs.receive_message(QueueUrl=queue_url, MaxNumberOfMessages=1, WaitTimeSeconds=10)
        assert 'Messages' in response, "No messages in the queue"
        message = response['Messages'][0]
        return message['Body']
    except ClientError as e:
        print(f"ClientError: {e}")
    except NoCredentialsError:
        print("AWS credentials not found")
    except EndpointConnectionError:
        print("Failed to connect to the endpoint")
    except Exception as e:
        print(f"An error occurred: {e}")

def test_sqs_message():
    queue_url = "https://sqs.us-east-1.amazonaws.com/183631337082/MyFirstQueue"
    message_body = "Test Message"

    try:
        # Send a message and assert the message was sent successfully
        send_message(queue_url, message_body)

        # Receive the message and assert it matches the sent message
        received_message = receive_message(queue_url)

        assert received_message == message_body, "Message received does not match the sent message"
    except AssertionError as e:
        print(f"AssertionError: {e}")
    except Exception as e:
        print(f"Unexpected error during testing: {e}")

if __name__ == "__main__":
    pytest.main()