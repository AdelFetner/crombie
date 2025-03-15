import express from "express";
import { userRouter } from "./routes/users.js";
import { productRouter } from "./routes/products.js";

const app = express();

app.use(logger)
    .use(express.static("public"))
    .use(express.urlencoded({ extended: true }))
    .use(express.json());

app.set("view engine", "ejs");

app.get("/", (req, res) => {
    res.render("index", { text: "Hello World!" });
});

app.use("/products", productRouter);

app.use("/users", userRouter);

function logger(req, res, next) {
    console.log(req.originalUrl);
    next();
}

app.listen(8000);
