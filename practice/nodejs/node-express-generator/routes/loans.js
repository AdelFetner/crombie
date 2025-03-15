const express = require("express");
const router = express.Router();
const {
    DynamoDBClient,
    PutItemCommand,
    QueryCommand,
} = require("@aws-sdk/client-dynamodb");
const { marshall, unmarshall } = require("@aws-sdk/util-dynamodb");
const dotenv = require("dotenv");
const { GetCommand, DynamoDBDocumentClient } = require("@aws-sdk/lib-dynamodb");

dotenv.config();

// init the dynamo client
const client = new DynamoDBClient({
    region: process.env.AWS_REGION,
    credentials: {
        accessKeyId: `${process.env.AWS_ACCESS_KEY_ID}`,
        secretAccessKey: process.env.AWS_SECRET_ACCESS_KEY,
    },
});
const docClient = DynamoDBDocumentClient.from(client);

// posts a loan to db

router.post("/", async (req, res) => {
    try {
        const data = {
            userId: req.body.userId,
            loanAmount: req.body.loanAmount,
            createdAt: new Date().toISOString(),
        };

        if (data.userId === undefined || data.loanAmount === undefined) {
            return res
                .status(400)
                .json({ error: "userId and loanAmount are required" });
        }

        const command = new PutItemCommand({
            TableName: "Loans",
            Item: marshall(data),
        });

        await client.send(command);

        res.status(201).json({
            message: "Loan saved successfully",
            data,
        });
    } catch (err) {
        console.error("POST Error:", err);
        res.status(500).json({
            error: "Failed to save loan",
            details: err.message,
        });
    }
});

// GET: Fetch loans by userId
// router.get("/", async (req, res) => {
//     try {
//         const userId = req.query.userId;

//         // Validate userId exists
//         if (!userId) {
//             return res.status(400).json({ error: "userId is required" });
//         }

//         const command = new QueryCommand({
//             TableName: "Loans",
//             KeyConditionExpression: "userId = :userId",
//             ExpressionAttributeValues: marshall({
//                 ":userId": userId,
//             }),
//         });

//         const { Items } = await client.send(command);
//         const loans = Items?.map((item) => unmarshall(item)) || [];
//         res.status(200).json(loans);
//     } catch (err) {
//         console.error("GET Error:", err);
//         res.status(500).json({
//             error: "Failed to fetch loans",
//             details: err.message,
//         });
//     }
// });
const log = (msg) => console.log(`[SCENARIO] ${msg}`);
router.get("/", async (req, res) => {
    console.log("GET /api/loans");
    const userId = req.query.userId;

    if (!userId) {
        return res.status(400).json({ error: "userId is required" });
    }

    const queryCommand = new QueryCommand({
        TableName: "Loans",
        KeyConditionExpression: "userId = :userId",
        ExpressionAttributeValues: marshall({
            ":userId": userId,
        }),
    });

    try {
        const response = await docClient.send(queryCommand);
        res.status(200).json(response.Items);
    } catch (error) {
        console.error("DynamoDB Error:", error);
        res.status(500).json({ error: "Failed to fetch loans" });
    }
});

module.exports = router;
