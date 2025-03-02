import { PrismaClient } from "@prisma/client";
import { parseArgs } from "node:util";

const prisma = new PrismaClient();

const options = {
    environment: { type: "string" },
};

async function seed() {
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
            const additionalProducts = await prisma.product.createMany({
                data: [
                    {
                        name: "Sunglasses",
                        description: "Stylish sunglasses for summer",
                        image: "https://picsum.photos/600",
                        price: 80,
                    },
                    {
                        name: "Watch",
                        description: "Elegant wristwatch with leather strap",
                        image: "https://picsum.photos/600",
                        price: 120,
                    },
                    {
                        name: "Backpack",
                        description: "Durable backpack for everyday use",
                        image: "https://picsum.photos/600",
                        price: 50,
                    },
                    {
                        name: "Sneakers",
                        description: "Comfortable sneakers for casual wear",
                        image: "https://picsum.photos/600",
                        price: 90,
                    },
                    {
                        name: "Jacket",
                        description: "Waterproof jacket for outdoor activities",
                        image: "https://picsum.photos/600",
                        price: 110,
                    },
                    {
                        name: "Scarf",
                        description: "Soft wool scarf for winter",
                        image: "https://picsum.photos/600",
                        price: 35,
                    },
                    {
                        name: "Gloves",
                        description: "Touchscreen-compatible gloves",
                        image: "https://picsum.photos/600",
                        price: 25,
                    },
                    {
                        name: "Dress",
                        description: "Elegant evening dress",
                        image: "https://picsum.photos/600",
                        price: 150,
                    },
                    {
                        name: "Tie",
                        description: "Silk tie for formal occasions",
                        image: "https://picsum.photos/600",
                        price: 40,
                    },
                    {
                        name: "Socks",
                        description: "Comfortable cotton socks, pack of 3",
                        image: "https://picsum.photos/600",
                        price: 15,
                    },
                    {
                        name: "Laptop Bag",
                        description:
                            "Sleek laptop bag with multiple compartments",
                        image: "https://picsum.photos/600",
                        price: 70,
                    },
                    {
                        name: "Umbrella",
                        description: "Compact automatic umbrella",
                        image: "https://picsum.photos/600",
                        price: 20,
                    },
                    {
                        name: "Headphones",
                        description: "Wireless noise-cancelling headphones",
                        image: "https://picsum.photos/600",
                        price: 200,
                    },
                    {
                        name: "Water Bottle",
                        description: "Insulated stainless steel water bottle",
                        image: "https://picsum.photos/600",
                        price: 25,
                    },
                    {
                        name: "Yoga Mat",
                        description: "Non-slip eco-friendly yoga mat",
                        image: "https://picsum.photos/600",
                        price: 40,
                    },
                    {
                        name: "Wallet",
                        description: "Genuine leather bifold wallet",
                        image: "https://picsum.photos/600",
                        price: 45,
                    },
                    {
                        name: "Sunscreen",
                        description: "SPF 50 waterproof sunscreen lotion",
                        image: "https://picsum.photos/600",
                        price: 15,
                    },
                    {
                        name: "Portable Charger",
                        description: "10000mAh fast-charging power bank",
                        image: "https://picsum.photos/600",
                        price: 35,
                    },
                    {
                        name: "Fitness Tracker",
                        description: "Smart fitness and activity tracker",
                        image: "https://picsum.photos/600",
                        price: 100,
                    },
                    {
                        name: "Travel Pillow",
                        description: "Memory foam neck support travel pillow",
                        image: "https://picsum.photos/600",
                        price: 30,
                    },
                ],
            });
            console.log({ alice, additionalProducts });
            break;
        case "production":
            /** data for your production */
            break;
        default:
            break;
    }
}

seed()
    .then(async () => {
        await prisma.$disconnect();
    })
    .catch(async (e) => {
        console.error(e);
        await prisma.$disconnect();
        process.exit(1);
    });
