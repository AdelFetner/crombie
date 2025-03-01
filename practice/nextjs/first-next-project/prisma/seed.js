import { PrismaClient } from "@prisma/client";
import { parseArgs } from "node:util";

const prisma = new PrismaClient();

const options = {
    environment: { type: "string" },
};

async function main() {
    const {
        values: { environment },
    } = parseArgs({ options });

    switch (environment) {
        case "development":
            /** data for your development */
            const alice = await prisma.user.upsert({
                where: { email: "alice@example.com" },
                update: {},
                create: {
                    username: "Alice",
                    email: "alice@example.com",
                    password: "alice123",
                    image: "https://picsum.photos/600",
                    Cart: {
                        create: {
                            quantity: 1,
                            products: {
                                create: [
                                    {
                                        name: "Shirt",
                                        description:
                                            "Red shirt, spring 2020 collection",
                                        image: "https://picsum.photos/600",
                                        price: 20,
                                    },
                                    {
                                        name: "Pants",
                                        description:
                                            "Blue pants, spring 2020 collection",
                                        image: "https://picsum.photos/600",
                                        price: 30,
                                    },
                                    {
                                        name: "Shoes",
                                        description:
                                            "White shoes, spring 2020 collection",
                                        image: "https://picsum.photos/600",
                                        price: 150,
                                    },
                                    {
                                        name: "Hat",
                                        description:
                                            "Black hat, spring 2020 collection",
                                        image: "https://picsum.photos/600",
                                        price: 25,
                                    },
                                ],
                            },
                        },
                    },
                },
            });
            console.log({ alice });
            break;
        case "production":
            /** data for your production */
            break;
        default:
            break;
    }
}

main()
    .then(async () => {
        await prisma.$disconnect();
    })
    .catch(async (e) => {
        console.error(e);
        await prisma.$disconnect();
        process.exit(1);
    });
