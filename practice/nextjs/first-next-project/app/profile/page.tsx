import { ProfileCard } from '@/components/profile/ProfileCard'
import React from 'react'

interface User {
    username: string,
    email: string,
    img: string
}

const user: User = {
    username: "pepito",
    email: "pepito@gmail.com",
    img: "/userPFP.png"
}

export default function ProfilePage() {
    return (
        <main className='flex flex-col items-center justify-center h-screen min-h-full w-full min-w-full'>
            <h1>Your profile</h1>
            <ProfileCard userData={user} />
        </main>
    )
}
