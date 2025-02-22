# AI Chatbot with Ollama

This project is an AI chatbot utilizing Ollama for natural language processing. The chatbot runs in a Docker container and communicates with an AI model hosted locally.

## Prerequisites

- Docker installed on your machine
- .NET SDK installed

## Getting Started

### Step 1: Run the Ollama Docker Container

To start the Ollama AI model in a Docker container, execute the following command:

```sh
docker run -d -v ollama_data:/root/.ollama -p 11434:11434 --name ollama ollama/ollama:latest
```

This command:
- Runs the container in detached mode (`-d`)
- Mounts a volume (`ollama_data`) to persist data
- Maps port `11434` for API access
- Names the container `ollama`
- Uses the `ollama/ollama:latest` image

### Step 2: Build and Run the Chatbot

Ensure you have .NET installed and then execute:

```sh
dotnet run
```

This will start the chatbot application, which will continuously prompt the user for input and provide AI-generated responses.

## Stopping the Container

To stop and remove the running container, use:

```sh
docker stop ollama && docker rm ollama
```

## License

This project is released under the MIT License.

