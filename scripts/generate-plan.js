import fs from "fs"
import { BedrockRuntimeClient, InvokeModelCommand } from "@aws-sdk/client-bedrock-runtime"

const promptTemplate = fs.readFileSync("ai/prompts/jira-planning.prompt.md", "utf8")

const prompt = promptTemplate
  .replace("{{SUMMARY}}", process.env.SUMMARY || "")
  .replace("{{DESCRIPTION}}", process.env.DESCRIPTION || "")
  .replace("{{ACCEPTANCE}}", process.env.ACCEPTANCE || "")
  .replace("{{CODE_CONTEXT}}", "Repository source code is available locally")

const client = new BedrockRuntimeClient({
  region: "us-east-1",
  credentials: {
    accessKeyId: process.env.BEDROCK_API_KEY,
    secretAccessKey: process.env.BEDROCK_API_KEY
  }
})

const command = new InvokeModelCommand({
  modelId: "anthropic.claude-3-sonnet-20240229-v1:0",
  contentType: "application/json",
  accept: "application/json",
  body: JSON.stringify({
    anthropic_version: "bedrock-2023-05-31",
    max_tokens: 2000,
    messages: [
      {
        role: "user",
        content: prompt
      }
    ]
  })
})

const response = await client.send(command)

const result = JSON.parse(new TextDecoder().decode(response.body))

const plan = result.content[0].text

fs.writeFileSync("plan.md", plan)
