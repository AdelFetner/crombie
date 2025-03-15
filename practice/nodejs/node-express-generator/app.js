const express = require("express");
const logger = require("morgan");
const cors = require("cors");
const loansRouter = require("./routes/loans");
// env vars
require("dotenv").config();

const app = express();

// middleware
app.use(logger("dev"));
app.use(cors());
app.use(express.json());

// routes
app.get("/", (req, res) => {
    res.status(200).json({ message: "Welcome to the Loan API" });
});

app.use("/api/loans", loansRouter);

// Error handling
app.use((err, req, res, next) => {
    res.status(500).json({ error: "Server error" });
});

module.exports = app;
