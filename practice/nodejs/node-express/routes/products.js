import { Router } from "express";
export const productRouter = Router();

const products = [
    {
        id: 1,
        name: "Product 1",
        description: "Description 1",
    },
    {
        id: 2,
        name: "Product 2",
        description: "Description 2",
    },
    {
        id: 3,
        name: "Product 3",
        description: "Description 3",
    },
];
productRouter.get("/", (req, res) => {
    res.render("products", { products });
});

productRouter
    .route("/:id")
    .get((req, res) => {
        const { id } = req.params;
        const product = products.find((product) => product.id === Number(id));
        res.render("product", { product });
    })
    .post((req, res) => {
        const { id } = req.params;
        res.send(`Product created ${id}`);
    })
    .put((req, res) => {
        const { id } = req.params;
        res.send(`Product updated ${id}`);
    })
    .delete((req, res) => {
        const { id } = req.params;
        res.send(`Product deleted ${id}`);
    });
