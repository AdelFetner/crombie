import { Router } from "express";

export const userRouter = Router();

const users = [
    {
        id: 1,
        name: "User 1",
        email: "hola@hola.com",
    },
    {
        id: 2,
        name: "User 2",
        email: "hola@hola.com",
    },
    {
        id: 3,
        name: "User 3",
        email: "hola@hola.com",
    },
];
userRouter.get("/", (req, res) => {
    const { name, email, id } = req.query;
    console.log(name, email, id);
    res.status(200).json(users);
});

userRouter.get("/new", (req, res) => {
    res.render("users/new");
});

userRouter.post("/", (req, res) => {
    const isValid = true;
    console.log(users);
    if (isValid) {
        users.push({
            name: req.body.name,
            email: req.body.email,
            id: users.length + 1,
        });
        res.redirect(`/users/${users.length}`);
    } else {
        res.render("users/new", { name: req.body.name, email: req.body.email });
    }
});

userRouter
    .route("/:id")
    .get((req, res) => {
        const { id } = req.params;
        res.send(`User ${id}, name: ${users[id - 1].name}`);
    })
    .post((req, res) => {
        const { id } = req.params;
        res.send(`User created ${id}`);
    })
    .put((req, res) => {
        const { id } = req.params;
        res.send(`User updated ${id}`);
    })
    .delete((req, res) => {
        const { id } = req.params;
        res.send(`User deleted ${id}`);
    });

userRouter.param("id", (req, res, next, id) => {
    // console.log(`User ${id}`);
    next();
});
