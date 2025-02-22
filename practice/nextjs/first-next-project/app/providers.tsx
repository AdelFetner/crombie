"use client";

import { HeroUIProvider } from "@heroui/react";
import { useRouter } from "next/navigation";
import React from "react";

type children = {
    children: React.ReactNode;
};

export const Providers = ({ children }: children) => {
    const router = useRouter();

    return (
        <HeroUIProvider navigate={router.push}>
            {children}
        </HeroUIProvider>
    );
};