import { prisma } from '@/lib/db'
import Image from 'next/image'
import Link from 'next/link'
import { notFound } from 'next/navigation'

export async function generateStaticParams(): Promise<{ user: string }[]> {
    return (await prisma.user.findMany()).map(user => ({
        user: user.username.toLowerCase().replace(/ /g, '-'),
    }))
}

export async function generateMetadata({ params }: Params) {
    const userName = params.user.replace(/-/g, ' ')
    const user = await prisma.user.findFirst({
        where: {
            username: userName
        },
        select: {
            username: true,
            email: true,
        }
    })

    if (!user) return { title: 'User Not Found' }

    return {
        title: user.username,
        description: `username: ${user.username}, email: ${user.email}`
    }
}

interface Params {
    params: {
        user: string
    }
}

type User = {
    username: string
    email: string
    image: string | null
}

export default async function ProductPage({ params }: Params) {
    const userName = params.user.replace(/-/g, ' ')

    const user: User | null = await prisma.user.findFirst({
        where: {
            username: userName
        },
        select: {
            username: true,
            email: true,
            image: true
        }
    })

    if (!user) return notFound()
    const { username, email, image } = user

    return (
        <main className="w-screen h-screen max-h-screen container mx-auto px-4 flex items-center justify-center">
            <article className="max-w-sm bg-white border border-gray-200 rounded-lg shadow-sm dark:bg-gray-800 dark:border-gray-700">
                <Link href="#">
                    <Image className="rounded-t-lg" src={image ?? "https://picsum.photos/600"} height={400} width={400} alt={`Image of ${username}`} />
                </Link>
                <section className="p-5">
                    <h1 className="mb-2 text-2xl font-bold tracking-tight text-gray-900 dark:text-white">{username}</h1>
                    <p className="mb-3 font-normal text-gray-700 dark:text-gray-400">{email}</p>
                </section>
            </article>

        </main>
    )
}